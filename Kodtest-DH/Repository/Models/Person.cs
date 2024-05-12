using System.ComponentModel.DataAnnotations;

namespace Kodtest_DH.Repository;

/// <summary>
/// Person entity
/// Separator get its value in code, witch is why it's not annotated
/// </summary>
public class Person
{
    [Key]
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(15)]
    public string PhoneNumber { get; set; }
}