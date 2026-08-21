// Polyfill required for C# 9+ `init` accessors and records on .NET Framework targets.
// net5.0+ ships this type in the BCL, so it is only compiled for the net472 target.
#if NET472
using System.ComponentModel;

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class IsExternalInit
    {
    }
}
#endif
