#include <stdio.h>
#include <stdlib.h>

//this is the bar.c file


struct foo
{
    int value;
    char glyph;   
}typedef foo;

//this is the foo.c file



int main()
{
    foo f = {127, 'c'};
    printf("Hello world from main.c!\n");
    printf("%d, %c\n", f.value, f.glyph);
    return 0;
}

//this is the main.c file
