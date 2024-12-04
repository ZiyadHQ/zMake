#include <stdio.h>
#include <stdlib.h>

int fib(int a)
{
    if(a < 2) return a;
    return fib(a - 1) + fib(a - 2);
}

//this is the bar.c file