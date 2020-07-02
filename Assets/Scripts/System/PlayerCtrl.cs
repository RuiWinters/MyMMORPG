internal class PlayerCtrl : Singleton<PlayerCtrl>, ISystemCtrl
{
    public string LastInWorldMapPos { get; internal set; }
    public int LastInWorldMapId { get; internal set; }

    public void OpenView(WindowUIType type)
    {
        throw new System.NotImplementedException();
    }
}