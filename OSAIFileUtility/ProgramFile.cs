using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OSAIFileUtility
{
    class ProgramFile
    {
        public ProgramFile()
        {
            Program_Name = "";
            Size = 0;
            Description = "";
        }

        public ProgramFile(string strDirListingResult)
            : this()
        {
            long lngSize = 0;


            Program_Name = strDirListingResult.Substring(0, 10).Trim();
            Description = strDirListingResult.Substring(18).Trim();
            long.TryParse(strDirListingResult.Substring(10, 8), out lngSize);
            Size = lngSize;
        }

        public string Program_Name { get; set; }
        public long Size { get; set; }
        public string Description { get; set; }

    }
}
