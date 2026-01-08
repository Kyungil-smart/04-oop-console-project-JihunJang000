public class CombatScene : Scene
{
    private MenuList _combatMenu;

    public CombatScene()
    {
        Init();
    }

    public void Init()
    {
        _combatMenu = new MenuList();
        _combatMenu.Add("공격", Attack);
        _combatMenu.Add("마법", Magic);
        _combatMenu.Add("회피", Avoid);
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
        GameManager.GameName.Print(ConsoleColor.Yellow);
        
        _combatMenu.Render(8, 5);
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
    
    public void Avoid()
    {
        
    }
    
}