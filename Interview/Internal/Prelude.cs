namespace Interview;

public static class Prelude
{
    public static T NoImpl<T>() => throw new NotImplementedException();
}