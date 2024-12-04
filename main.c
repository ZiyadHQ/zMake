
##In foo.c

int main()
{
    foo f = {127, 'c'};
    printf("Hello world from main.c!\n");
    printf("%d, %c\n", f.value, f.glyph);
    return 0;
}

//this is the main.c file