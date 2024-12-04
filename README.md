this is a simple implementation of a build system for C, it starts from the file that contains the main function entry point, after that it checks for '##In <FileName>' lines and adds them to a tree of includes by running a DFS
through the includes, finally it creates a new file by concatenating all the found files of the program starting from the deepest in the tree all the way to the root main file.
Note: includes for a single file must only exist once within a project, files in the same tree level shouldn't depend on each other.

included is an example C program that implements a struct and fibonacci in different files, you can then try to compile the "newFile.cs" file and see the resulting C executable.

main.c <- foo.c <- bar.c

result:

newFile.c
{
  bar.c
  foo.c
  main.c
}
