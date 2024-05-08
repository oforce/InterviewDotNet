namespace Interview.Test.Internal;

public static  class ThenExtensions
{
    public static Task<Tb> Then<Ta, Tb>(this Task<Ta> a, Func<Ta, Tb> run) => throw new NotSupportedException();

    public static T Then<T>(this T a, Action<T>? run)
    {
        if (a == null) throw new ArgumentNullException(nameof(a));
        if(a is Task) throw new NotSupportedException("Do not call Then on a Task. Await the Task and call Then on the result.");
        run?.Invoke(a);
        return a;
    }

    public static Tb Then<Ta, Tb>(this Ta a, Func<Ta, Tb> run)
    {
        if (a == null) throw new ArgumentNullException(nameof(a));
        return run.Invoke(a);
    }
}