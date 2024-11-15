using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using NpgsqlTypes;

namespace TestSearchAutoComplete.Models;

[Table("notes")]
public class Note
{
    [Key]
    [JsonIgnore]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("content")]
    public required string Content { get; set; }

    [JsonIgnore]
    [Column("search_vector")]
    public NpgsqlTsVector? SearchVector { get; set; }
}
