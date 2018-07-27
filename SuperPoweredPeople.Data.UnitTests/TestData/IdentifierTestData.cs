using System.Collections.Generic;

namespace SuperPoweredPeople.Data.UnitTests.TestData
{
    public class IdentifierTestData
    {
        public static IEnumerable<object[]> GetAddDataParameters()
        {
            yield return new object[] { null };
            yield return new object[] { string.Empty };
            yield return new object[] { "      " };
        }

        public static IEnumerable<object[]> GetIsMatchParameters()
        {
            yield return new object[] { null };
            yield return new object[] { string.Empty };
            yield return new object[] { "      " };
        }

        public static IEnumerable<object[]> GetSuperHeroIsMatchTrue()
        {
            yield return new object[] { "jan" };
            yield return new object[] { "Bert" };
            yield return new object[] { "coleen" };
            yield return new object[] { "Borat" };
            yield return new object[] { "Zeke" };
        }

        public static IEnumerable<object[]> GetSuperHeroIsMatchFalse()
        {
            yield return new object[] { "dear" };
            yield return new object[] { "Dear" };
            yield return new object[] { "asdf" };
            yield return new object[] { "aDsf" };
            yield return new object[] { "AsfD" };
        }

        public static IEnumerable<object[]> GetVillainIsMatchTrue()
        {
            yield return new object[] { "dear" };
            yield return new object[] { "Dear" };
            yield return new object[] { "asdf" };
            yield return new object[] { "aDsf" };
            yield return new object[] { "AsfD" };
        }

        public static IEnumerable<object[]> GetVillainIsMatchFalse()
        {
            yield return new object[] { "jan" };
            yield return new object[] { "Bert" };
            yield return new object[] { "coleen" };
            yield return new object[] { "Borat" };
            yield return new object[] { "Zeke" };
        }
    }
}
