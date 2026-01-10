

using System.Runtime.InteropServices.Marshalling;

public class PlayerCharacter : GameObject
{
    public ObservableProperty<int> Health = new ObservableProperty<int>(5);
    public ObservableProperty<int> Mana = new ObservableProperty<int>(5);
    private string _healthGauge;
    private string _manaGauge;
    
    public Tile[,] Field { get; set; }
    private Inventory _inventory;
    public bool IsActiveControl { get; private set; }

    public PlayerCharacter() => Init();

    public void Init()
    {
        Symbol = 'P';
        IsActiveControl = true;
        Health.AddListener(SetHealthGauge);
        Mana.AddListener(SetManaGauge);
        _healthGauge = "■■■■■■■■■■";
        _manaGauge = "■■■■■■■■■■";
        _inventory = new Inventory(this);
    }

    public void Update()
    {
        if (InputManager.GetKey(ConsoleKey.I))
        {
            HandleControl();
        }
        
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            Move(Vector.Up);
            _inventory.SelectUp();
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            Move(Vector.Down);
            _inventory.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.LeftArrow))
        {
            Move(Vector.Left);
        }

        if (InputManager.GetKey(ConsoleKey.RightArrow))
        {
            Move(Vector.Right);
        }

        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _inventory.Select();
        }

        if (InputManager.GetKey(ConsoleKey.T))
        {
            Health.Value--;
        }
    }

    public void HandleControl() //인벤토리 실행했을때 플레이어 못 움직이게 함.
    {
        _inventory.IsActive = !_inventory.IsActive;
        IsActiveControl = !_inventory.IsActive;
        Debug.LogWarning($"{_inventory._itemMenu.CurrentIndex}");
    }

    private void Move(Vector direction)
    {
        if (Field == null || !IsActiveControl) return;
        
        Vector current = Position;
        Vector nextPos = Position + direction;
        
        // 1. 맵 바깥은 아닌지?
        // 2. 벽인지?

        GameObject nextTileObject = Field[nextPos.Y, nextPos.X].OnTileObject;

        if (nextTileObject != null)
        {
            if (nextTileObject is IInteractable)
            {
                (nextTileObject as IInteractable).Interact(this);
                if (Field == null) return;
            }
        }

        Field[Position.Y, Position.X].OnTileObject = null;
        Field[nextPos.Y, nextPos.X].OnTileObject = this;
        Position = nextPos;
    }

    public void Render()
    {
        DrawHealthGauge();
        DrawManaGauge();
        _inventory.Render();
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }

    public void DrawManaGauge()
    {
        Console.SetCursorPosition(0, 2);
        _manaGauge.Print(ConsoleColor.Blue);
    }

    public void DrawHealthGauge()
    {
        Console.SetCursorPosition(0, 1);
        _healthGauge.Print(ConsoleColor.Red);
    }

    public void SetHealthGauge(int health)
    {
        switch (health)
        {
            case 10:
                _healthGauge = "■■■■■■■■■■";
                break;
            case 9:
                _healthGauge = "■■■■■■■■■□";
                break;
            case 8:
                _healthGauge = "■■■■■■■■□□";
                break;
            case 7:
                _healthGauge = "■■■■■■■□□□";
                break;
            case 6:
                _healthGauge = "■■■■■■□□□□";
                break;
            case 5:
                _healthGauge = "■■■■■□□□□□";
                break;
            case 4:
                _healthGauge = "■■■■□□□□□□";
                break;
            case 3:
                _healthGauge = "■■■□□□□□□□";
                break;
            case 2:
                _healthGauge = "■■□□□□□□□□";
                break;
            case 1:
                _healthGauge = "■□□□□□□□□□";
                break;
        }
    }

    public void SetManaGauge(int mana)
    {
        switch (mana)
        {
            case 10:
                _manaGauge = "■■■■■■■■■■";
                break;
            case 9:
                _manaGauge = "■■■■■■■■■□";
                break;
            case 8:
                _manaGauge = "■■■■■■■■□□";
                break;
            case 7:
                _manaGauge = "■■■■■■■□□□";
                break;
            case 6:
                _manaGauge = "■■■■■■□□□□";
                break;
            case 5:
                _manaGauge = "■■■■■□□□□□";
                break;
            case 4:
                _manaGauge = "■■■■□□□□□□";
                break;
            case 3:
                _manaGauge = "■■■□□□□□□□";
                break;
            case 2:
                _manaGauge = "■■□□□□□□□□";
                break;
            case 1:
                _manaGauge = "■□□□□□□□□□";
                break;
        }
    }

    public void Heal(int value)
    {
        Health.Value = 10;
        Mana.Value = 10;
    }
}