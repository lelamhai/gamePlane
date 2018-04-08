public class Singleton
{
    private static Singleton instance;
    private Singleton() { }
    public static Singleton Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
    private int point;
    public int Point
    {
        get
        {
            return point;
        }

        set
        {
            point = value;
        }
    }
}