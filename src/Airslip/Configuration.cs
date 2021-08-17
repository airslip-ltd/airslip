using System;

namespace Airslip
{
    public static class Configuration
    {
        public static string GenerateStatementDescriptorSuffix(int length = 5)
        {
            return $"_{Guid.NewGuid().ToString("N")[..length]}";
        }
    }
}   