using System;
using System.Collections.Generic;

namespace PrimeNumbers.Shared.PrimeCalculation
{
    public static class PrimeCalculator
    {
        public static PrimeCalculationResult GetPrimes(ulong number)
        {
            List<ulong> primes;
            PrimeCalculationResult result = new PrimeCalculationResult();

            primes = DivideToPrimeFactors(number);

            if(IsNumberPrime(primes))
            {
                result.IsPrime = true;
                result.Primes = null;
            }
            else
            {
                result.IsPrime = false;
                result.Primes = primes.ToArray();
            }

            return result;
        }

        /// Returns if a number is prime by its prime dividors
        private static bool IsNumberPrime(List<ulong> primesOfNumber) => primesOfNumber.Count == 1;


        /*
         *  Code taken from GeeksForGeeks
         *  Source: https://www.geeksforgeeks.org/print-all-prime-factors-of-a-given-number/
         */

        private static List<ulong> DivideToPrimeFactors(ulong n)
        {
            List<ulong> factors = new();

            // Print the number of 2s that divide n 
            while (n % 2 == 0)
            {
                factors.Add(2);
                n /= 2;
            }

            // n must be odd at this point. So we can 
            // skip one element (Note i = i +2) 
            for (ulong i = 3; i <= Math.Sqrt(n); i += 2)
            {
                // While i divides n, print i and divide n 
                while (n % i == 0)
                {
                    factors.Add(i);
                    n /= i;
                }
            }

            // This condition is to handle the case when 
            // n is a prime number greater than 2 
            if (n > 2)
            {
                factors.Add(n);
            }

            return factors;
        }

    }
}
