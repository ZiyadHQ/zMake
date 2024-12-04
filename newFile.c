#include <stdio.h>
#include <stdlib.h>

int fib(int a)
{
    if(a < 2) return a;
    return fib(a - 1) + fib(a - 2);
}

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

    printf("%d", fib(50));

    return 0;
}

//this is the main.c file
