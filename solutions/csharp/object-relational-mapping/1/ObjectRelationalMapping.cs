public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin() => database.BeginTransaction();
    
    public void Write(string data)
    {
        try 
        {
            database.Write(data);
        }
        catch (InvalidOperationException _ )
        {
            database.Dispose();
        }   
    }

    public void Commit()
    {
        try 
        {
            database.EndTransaction();
        }
        catch (InvalidOperationException _ )
        {
            database.Dispose();
        }   
    }

    public void Dispose() => database.Dispose();
}
