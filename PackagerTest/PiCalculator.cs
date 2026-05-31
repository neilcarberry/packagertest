using System.Numerics;

namespace PackagerTest;

public static class PiCalculator
{
    /// <summary>
    /// Calculates Pi to the specified number of decimal places (up to 1000).
    /// Uses the Machin-like formula with arbitrary precision via BigInteger arithmetic.
    /// </summary>
    public static string Calculate(int decimalPlaces = 1000)
    {
        if (decimalPlaces < 1 || decimalPlaces > 1000)
            throw new ArgumentOutOfRangeException(nameof(decimalPlaces), "Must be between 1 and 1000.");

        // Work with extra digits to avoid rounding errors
        int digits = decimalPlaces + 10;
        BigInteger scale = BigInteger.Pow(10, digits);

        // Machin's formula: pi/4 = 4*arctan(1/5) - arctan(1/239)
        BigInteger pi = 4 * (4 * ArctanSeries(5, scale) - ArctanSeries(239, scale));

        // pi is scaled by 10^digits; convert to string
        string raw = pi.ToString();

        // Ensure enough digits (pad left if needed)
        raw = raw.PadLeft(digits + 1, '0');

        // Insert decimal point after '3'
        string result = raw[0] + "." + raw[1..(decimalPlaces + 1)];
        return result;
    }

    // Computes arctan(1/x) * scale using the Taylor series:
    // arctan(1/x) = 1/x - 1/(3x^3) + 1/(5x^5) - ...
    private static BigInteger ArctanSeries(long x, BigInteger scale)
    {
        BigInteger xSquared = x * x;
        BigInteger term = scale / x;
        BigInteger sum = term;

        for (long divisor = 3; term != 0; divisor += 2)
        {
            term /= xSquared;
            sum += (divisor % 4 == 3) ? -term / divisor : term / divisor;
        }

        return sum;
    }
}
