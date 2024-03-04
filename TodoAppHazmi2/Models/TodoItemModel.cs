using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAppHazmi2.Models
{
    public class TodoItemModel
    {
        [Key]
        [Sieve(CanFilter = true, CanSort = true)]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Item Name is required")]
        [Column(TypeName = "nvarchar(100)")]
        [Sieve(CanFilter = true, CanSort = true)]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Item Description is required")]
        [Column(TypeName = "nvarchar(100)")]
        [Sieve(CanFilter = true, CanSort = true)]
        public string ItemDescription { get; set; }


        [Required(ErrorMessage = "Due Date is required")]
        [Column(TypeName = "datetime")]
        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = " Item Status is required")]
        [Column(TypeName = "nvarchar(100)")]
        [Sieve(CanFilter = true, CanSort = true)]
        public string ItemStatus { get; set; }
    }
}
