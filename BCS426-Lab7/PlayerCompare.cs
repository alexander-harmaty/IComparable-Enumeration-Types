using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    public enum BaseballPlayerCompareType
    {
        Name,
        Salary,
        AtBats,
        HomeRuns,
        Hits
    }

    public class BaseballPlayerCompare : IComparer<BaseballPlayer>
    {
        private BaseballPlayerCompareType _compareType;

        public BaseballPlayerCompare(BaseballPlayerCompareType compareType) =>
            _compareType = compareType;

        #region IComparer<Person> Members
        public int Compare(BaseballPlayer x, BaseballPlayer y)
        {
            if (x is null && y is null) return 0;
            if (x is null) return 1;
            if (y is null) return -1;

            switch (_compareType)
            {
                case BaseballPlayerCompareType.Name:
                    return x.Name.CompareTo(y.Name);
                case BaseballPlayerCompareType.Salary:
                    return x.Salary.CompareTo(y.Salary);
                case BaseballPlayerCompareType.AtBats:
                    return x.AtBats.CompareTo(y.AtBats);
                case BaseballPlayerCompareType.HomeRuns:
                    return x.HomeRuns.CompareTo(y.HomeRuns);
                case BaseballPlayerCompareType.Hits:
                    return x.Hits.CompareTo(y.Hits);
                default:
                    throw new ArgumentException("unexpected compare type");
            }
        }

        #endregion
    }
}
