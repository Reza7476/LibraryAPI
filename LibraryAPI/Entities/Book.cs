namespace LibraryAPI.Entities;

public class Book
{
    public Book(string title, string genre, string publishDate, string auther)
    {
        Title = title;
        Genre = genre;
        PublishDate = publishDate;
        Auther = auther;
        Guard(title, genre, publishDate, auther);
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Genre { get; private set; }
    public string PublishDate { get; private set; }
    public string Auther { get; private set; }


    public void EditBook(string title, string genre, string publishYear, string auther)
    {
        Guard(title, genre, publishYear, auther);
        Title = title;
        Genre = genre;
        PublishDate = publishYear;
        Auther = auther;
    }


    public void Guard(string title, string genre, string publishYear, string auther)
    {
        if (string.IsNullOrEmpty(title))
        {
            throw new Exception("string value can not be  null");
        }

        if (string.IsNullOrEmpty(genre))
        {
            throw new Exception("string value can not be  null");
        }

        if (string.IsNullOrEmpty(publishYear))
        {
            throw new Exception("string value can not be  null");
        }

        if (string.IsNullOrEmpty(auther))
        {
            throw new Exception("string value can not be  null");
        }
    }

}
