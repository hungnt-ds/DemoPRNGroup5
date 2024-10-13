namespace Demo03.DemoXmlSerializer02;
public class Person
{
    public Person() { }
    public Person(decimal initialSalary) => Salary = initialSalary;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public HashSet<Person> Children { get; set; }
    //Salary property is not included
    protected decimal Salary { get; set; }
}

