public class CombatScene : Scene
{
    private MenuList _combatMenu;
    public PlayerCharacter player;
    public int monsterId;  //몬스터 번호
    private bool IsActiveControl = true;
    
    public CombatScene()
    {
        
        Init();
    }
    //전투를 하기 위해서는 우선 플레이어의 상태를 넘겨줘야 한다..
    //healthGage, manaGage 넘겨주고 플레이어의 위치는 기억 해두고
    //전투 종료시 or 몬스터 잡을 시 원래 플레이어의 위치로 내보내기
    //
    public void Init()
    {
        
        _combatMenu = new MenuList();
        _combatMenu.Add("공격", Attack);
        _combatMenu.Add("마법", Magic);
        _combatMenu.Add("포션", Posion);
        _combatMenu.Add("도망", Avoid);
    }
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
        Console.SetCursorPosition(5, 1);
        Monster.MonsterName[monsterId].Print(ConsoleColor.Yellow);
        Console.WriteLine();
        for (int i = 0; i < Monster.monsterSprites.GetLength(1); i++)
        {
            Console.Write("     ");
            Monster.monsterSprites[monsterId, i].Print(ConsoleColor.Yellow);
            Console.WriteLine();
        }
        
        _combatMenu.Render(8, 10);
    }

    public override void Exit()
    {
    }

    public void Attack()
    {
        
    }
    
    public void Magic()
    {
        
    }

    public void Posion()
    {
        
        player.HandleControl();
        player.Render();
    }
    public void Avoid()
    {
        SceneManager.Change("Town");
    }
    
}