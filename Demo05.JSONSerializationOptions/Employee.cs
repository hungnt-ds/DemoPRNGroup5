using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Demo05.JSONSerializationOptions;
public class Employee
{
    [JsonPropertyName("FullName")]
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
}
