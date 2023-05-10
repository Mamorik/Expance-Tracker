using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using Microsoft.Identity.Client;
using Syncfusion.EJ2.Charts;

namespace Expense_Tracker.Models;

public class Category
{
    private int id;

    [Key]
    public int CategoryId { get; set; }
    
    [Column(TypeName = "nvarchar(50)")]
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    
    [Column(TypeName = "nvarchar(5)")]
    public string Icon { get; set; } = "";
    
    [Column(TypeName = "nvarchar(10)")]
    public string Type { get; set; } = "Expense";

    [NotMapped]
    public string? TitleWithIcon
    {
        get
        {
            return this.Icon + this.Title;
        }
    }

}