namespace LogServiceModule
{
    public interface ITraceListener
    {
        void Write(string message);
        void WriteLine(string message);
    }
}