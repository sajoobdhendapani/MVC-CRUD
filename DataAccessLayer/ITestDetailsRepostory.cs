using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ITestDetailsRepostory
    {
        public TestDetail InsertSP(TestDetail details);
        public IEnumerable<TestDetail> ReadSP();
        public TestDetail DeleteSP(long id);
        public TestDetail UpdateSP(long id, TestDetail updtDetails);
        public TestDetail ReadByNumberSP(long id);
    }
}
