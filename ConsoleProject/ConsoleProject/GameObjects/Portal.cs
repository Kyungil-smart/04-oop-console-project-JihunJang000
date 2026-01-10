public class Portal : GameObject, IInteractable
{
    private int monsterId;
    public Portal(int monsterId) => Init(monsterId);
    public string Name { get; set; }
    //포탈 i번 - monsterSprites[i] 출력
    
    
    
    private void Init(int monsterId)
    {
        this.monsterId = monsterId;
        Symbol = 'o';
    }
    
    
    
    //플레이어의 정보와 portal[i]의 i를 전달 해야함.
    public void Interact(PlayerCharacter player)
    {
        
        SceneManager.Change("Combat", player, monsterId);
    }
}