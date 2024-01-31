namespace LibraryAPI.Entities;

public class Member
{
    public Member(string name, string email)
    {
        Guard(email ,name);
        Name = name;
        Email = email;
        RegisterDate = DateTime.Now;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime RegisterDate { get; private set; }




    public void EditMember(string name, string emil)
    {

        Guard(emil, name);
        Name = name;
        Email = emil;
    }

    public void Guard(string emil, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new Exception("input value is null or empty");
        }
        if (string.IsNullOrEmpty(emil))
        {
            throw new Exception("strig value is null or empty");
        }
    }

}



