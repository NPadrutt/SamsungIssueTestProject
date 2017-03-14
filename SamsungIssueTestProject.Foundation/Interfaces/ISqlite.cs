namespace SamsungIssueTestProject.Foundation.Interfaces
{
    /// <summary>
    ///     Used to inject the db path depending on the plat form to the context.
    /// </summary>
    public interface ISqlite
    {
        /// <summary>
        ///     Plattformspecific DB Path
        /// </summary>
        string DbPath { get; }
    }
}
