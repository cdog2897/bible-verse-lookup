using System;
using BibleVerse.Models;

namespace BibleVerse.Services
{
	public class SecurityService
	{
		SecurityDAO dao = new SecurityDAO();

		public List<VerseModel> getNewTestament(string st)
		{
			List<VerseModel> verses = dao.GetVerseBySearchTerm(st);
			List<VerseModel> returnThis = new List<VerseModel>();
			foreach(VerseModel verse in verses)
			{
				if(verse.BookId > 39)
				{
					returnThis.Add(verse);
				}
			}
			return returnThis;
		}

		public List<VerseModel> getOldTestament(string st)
		{
            List<VerseModel> verses = dao.GetVerseBySearchTerm(st);
            List<VerseModel> returnThis = new List<VerseModel>();
            foreach (VerseModel verse in verses)
            {
                if (verse.BookId < 40)
                {
                    returnThis.Add(verse);
                }
            }
			return returnThis;
        }

        public List<VerseModel> getBoth(string st)
        {
            List<VerseModel> verses = dao.GetVerseBySearchTerm(st);
            List<VerseModel> returnThis = new List<VerseModel>();
            foreach (VerseModel verse in verses)
            {
                returnThis.Add(verse);
            }
            return returnThis;
        }
    }
}

