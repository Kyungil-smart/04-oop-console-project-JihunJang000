public class Monster
{
    public static int[] health = {5, 10, 15};
    public static int[] attackDamage = {1, 2, 2};
    public static string[] MonsterName = { "Slime", "Owl", "Rabbit" };
    public static string[,] monsterSprites = new string[3,4]
    {
        {
            "  .---.   ",
            " / o o \\ ",
            "(   ^   ) ",
            " '-----'  "
        },
        {
            "  /\\_/\\   ",
            " ( o.o )  ",
            " (  -  )  ",
            "          "
        },
        {
            " /\\_/\\ ",
            "( >.< )  ///",
            " )   (",
            "(,,_,,)"
        }
    };
    
}