public class CombatScene : Scene
{
    private MenuList _combatMenu;
    public PlayerCharacter player;
    public int monsterId;  //몬스터 번호
    private bool IsActiveControl = true;
    private bool isPosionSelected = false;
    public CombatScene()
    {
        
        Init();
    }
    
    public void Init()
    {
        
        _combatMenu = new MenuList();
        _combatMenu.Add("공격", Attack);
        _combatMenu.Add("마법", Magic);
        _combatMenu.Add("포션", Posion);
        _combatMenu.Add("도망", Avoid);
    }
    
    //전투를 하기 위해서는 우선 플레이어의 상태를 넘겨줘야 한다..
    public void Setup(PlayerCharacter player, int monsterId)
    {
        this.player = player;
        this.monsterId = monsterId;
    }
    public override void Enter()
    {
        _combatMenu.Reset();
        Debug.Log("전투 진입");
    }
    public override void Update()
    {
        if (player.IsActiveControl == false) 
        {
            player.Update(); 
            return; // 전투 메뉴 조작은 스킵
        }
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            
            _combatMenu.SelectUp();
        } 
        
        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _combatMenu.SelectDown();
        } 

        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _combatMenu.Select();
        }
    }
    
    public override void Render()
    {
        player.DrawHealthGauge();
        player.DrawManaGauge();
        Console.SetCursorPosition(0, 4);
        Monster.MonsterName[monsterId].Print(ConsoleColor.Yellow);
        Console.WriteLine();
        Console.Write("체력: ");
        Monster.health[monsterId].ToString().Print(ConsoleColor.Yellow);
        Console.WriteLine();
        for (int i = 0; i < Monster.monsterSprites.GetLength(1); i++)
        {
            Console.Write("     ");
            Monster.monsterSprites[monsterId, i].Print(ConsoleColor.Yellow);
            Console.WriteLine();
        }
        Console.SetCursorPosition(0, 10);
        player.Render();
        
        if (player.IsActiveControl)
        {
            _combatMenu.Render(8, 11);
        }
        
    }

    public override void Exit()
    {
    }

    public void Attack()
    {
        Monster.health[monsterId]--;
        Console.SetCursorPosition(0, 10);
        Console.WriteLine("몬스터를 공격했다!");
        if (Monster.health[monsterId] <= 0)
        {
            Monster.isAlive[monsterId] = false;
            if (Monster.isAlive[0] == false && Monster.isAlive[1] == false && Monster.isAlive[2] == false)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 10);
                Console.WriteLine("게임 클리어!");
                Thread.Sleep(1000);
                GameManager.IsGameOver = true;
            }
            SceneManager.Change("Town");
        }
        Thread.Sleep(500);
        Monster.MonsterAttack(player, Monster.attackDamage[monsterId]);
    }
    
    public void Magic()
    {
        if (player.Mana.Value <= 0)
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("마나 부족");
            return;
        }
        
        player.Mana.Value--;
        Console.SetCursorPosition(0, 10);
        Console.WriteLine("몬스터를 마법 공격했다!");
        Monster.health[monsterId] = Monster.health[monsterId] -2;
        if (Monster.health[monsterId] <= 0)
        {
            Monster.isAlive[monsterId] = false;
            if (Monster.isAlive[0] == false && Monster.isAlive[1] == false && Monster.isAlive[2] == false)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 10);
                Console.WriteLine("게임 클리어!");
                Thread.Sleep(1000);
                GameManager.IsGameOver = true;
            }
            SceneManager.Change("Town");
        }
        Thread.Sleep(500);
        Monster.MonsterAttack(player, Monster.attackDamage[monsterId]);
    }

    public void Posion()
    {
        player.HandleControl();
        Console.SetCursorPosition(0, 10);
    }
    public void Avoid()
    {
        SceneManager.Change("Town");
    }
    
}