using System;
namespace BibleVerse.Models
{
	public class VerseModel
	{
        

        String[] bibleBooks = {"all is void", "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy", "Joshua",
            "Judges", "Ruth", "1 Samuel", "2 Samuel", "1 Kings", "2 Kings", "1 Chronicles", "2 Chronicles", "Ezra",
            "Nehemiah", "Esther", "Job", "Psalms", "Proverbs", "Ecclesiastes", "Song of Solomon", "Isaiah", "Jeremiah",
            "Lamentations", "Ezekiel", "Daniel", "Hosea", "Joel", "Amos", "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk",
            "Zephaniah", "Haggai", "Zechariah", "Malachi", "Matthew", "Mark", "Luke", "John", "Acts", "Romans", "1 Corinthians",
            "2 Corinthians", "Galatians", "Ephesians", "Philippians", "Colossians", "1 Thessalonians", "2 Thessalonians",
            "1 Timothy", "2 Timothy", "Titus", "Philemon", "Hebrews", "James", "1 Peter", "2 Peter", "1 John", "2 John",
            "3 John", "Jude", "Revelation" };

        public VerseModel(int bookId, int chapterId, int verseId, string text)
        {
            BookId = bookId;
            ChapterId = chapterId;
            VerseId = verseId;
            Text = text;
            BookName = bibleBooks[BookId];
        }


        public String Id { get; set; }
        public int BookId { get; set; }
        public int ChapterId { get; set; }
        public int VerseId { get; set; }
        public String Text { get; set; }
        public String BookName { get; set; }

        public override String ToString()
        {
            return bibleBooks[BookId] + " " + ChapterId + ":" + VerseId;
        }

        
    }
}

