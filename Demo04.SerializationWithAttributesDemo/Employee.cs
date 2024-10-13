using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demo04.SerializationWithAttributesDemo;
public class Employee
{
    public Employee() { }
    public Employee(decimal initialSalary)
    {
        Salary = initialSalary;
    }
    [JsonPropertyName("FullName")]
    public string Name { get; set; }
    [JsonIgnore]
    public string Email { get; set; }
    [JsonInclude]
    public decimal Salary;
}

//**** Serialize*****
//{
//  "FullName": "Jack",
//  "Salary": 1000
//}
//****Deserialize * ****
//Name: Jack, Salary: 1000