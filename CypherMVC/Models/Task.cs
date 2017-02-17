using CypherMVC.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;

namespace CypherMVC.Models
{
    [Bind(Exclude ="AssignedTo, AssociatedMessage, Category")]
    public class Task : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DueDate(ErrorMessage = "Date must be in the future")]
        public DateTime? DueDate { get; set; }
        [Required]
        public int AssignedToId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int AssociatedMessageId { get; set; }
        public DateTime? Created { get; set; }
        [StringLength(1000,MinimumLength =20)]
        public string Notes { get; set; }
        [Required]
        public bool Completed { get; set; }


        //Navigation Properties
        public virtual Admin AssignedTo { get; set; }
        public virtual Message AssociatedMessage { get; set; }
        public virtual Category Category { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if(Completed && string.IsNullOrWhiteSpace(Notes))
            {
                errors.Add(new ValidationResult("Notes are required when completing a task"));
            }

            return errors;
        }
    }
}