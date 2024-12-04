
using System.Reflection;
using System.Text.Json;

public class Start
{

    public struct FileRecord
    {
        public int depth;
        public String filePath;

        public override string ToString()
        {
            return $"depth: {depth}, path: {filePath}";
        }
    }

    public static List<FileRecord> getIncludes(FileRecord file)
    {
        List<FileRecord> list = [];
        int depth = file.depth;
        String root = "D:/zMake/";
        using (StreamReader reader = File.OpenText(root + file.filePath))
        {
            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                if (line.StartsWith("##In"))
                {
                    line = line.Split(' ')[1];
                    list.Add(new FileRecord
                    {
                        depth = depth + 1,
                        filePath = line
                    });
                }
            }
            depth++;
        }

        return list;
    }

    public static bool addUnique(List<FileRecord> list, FileRecord newRecord)
    {
        if (list.Any((FileRecord item) => item.filePath == newRecord.filePath)) return false;
        list.Add(newRecord);
        return true;
    }

    public static void Main(String[] args)
    {
        String root = "D:/zMake/";
        String mainFile = "main.c";
        List<FileRecord> list = [];
        List<FileRecord> visitedList = [];
        int depth = 0;

        FileRecord main = new FileRecord { depth = depth, filePath = mainFile };
        list.Add(main);

        while (list.Count != 0)
        {
            int listSize = list.Count;
            for (int i = 0; i < listSize; i++)
            {
                FileRecord fileRecord = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);

                if (visitedList.Any((e) => e.filePath == fileRecord.filePath))
                {
                    continue;
                }

                addUnique(visitedList, fileRecord);

                List<FileRecord> includes = getIncludes(fileRecord);
                foreach (FileRecord record in includes)
                {
                    addUnique(list, record);
                }
            }
            // foreach (FileRecord record in visitedList) Console.WriteLine(record);
        }

        visitedList.Sort((a, b) => b.depth.CompareTo(a.depth));
        foreach (FileRecord record in visitedList) Console.WriteLine(record);

        using (FileStream newFile = File.Open(root + "newFile.c", FileMode.OpenOrCreate, FileAccess.Write))
        using (StreamWriter writer = new StreamWriter(newFile))
        {
            foreach (FileRecord fileRecord in visitedList)
            {
                String[] fileContent = File.ReadLines(root + fileRecord.filePath).ToArray();
                for (int i = 0; i < fileContent.Length; i++)
                {

                    if (fileContent[i].StartsWith("##In"))
                    {
                        fileContent[i] = "";
                    }
                }
                foreach (String line in fileContent)
                {
                    writer.WriteLine(line);
                }
            }

        }

    }

}