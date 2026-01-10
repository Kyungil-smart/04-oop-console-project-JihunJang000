public class CreditScene : Scene
{
    private MenuList _titleMenu;

    public CreditScene()
    {
        Init();
    }

    public void Init()
    {
        _titleMenu = new MenuList();
        _titleMenu.Add("돌아가기", ReturnToMenu);
    }

    public override void Enter()
    {
        _titleMenu.Reset();
    }

    public override void Update()
    {
        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _titleMenu.Select();
        }
    }
    
    public override void Render()
    {
        Console.SetCursorPosition(0, 1);
        Console.WriteLine("도와주신 분: 김재성 강사님, 최영민 강사님\n만든사람: 장지훈");
        
        _titleMenu.Render(8, 5);
    }

    public override void Exit()
    {
    }

    public void ReturnToMenu()
    {
        SceneManager.Change("Title");
    }
}