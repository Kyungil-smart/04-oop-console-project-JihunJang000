public class Monster
{
    public static int[] health = {5, 10, 15};
    public static int[] attackDamage = {1, 2, 2};
    public static bool[] isAlive = { true, true, true };
    public static string[] MonsterName = { "Slime", "Owl", "Rabbit" };
    public static string[] monsterItem = { "liquid", "feather", "ears" };
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

    public static void MonsterAttack(PlayerCharacter player, int damage)
    {
        player.Health.Value = player.Health.Value - damage;
        if (player.Health.Value <= 0)
        {
            GameManager.IsGameOver = true;
        }
    }
    
}