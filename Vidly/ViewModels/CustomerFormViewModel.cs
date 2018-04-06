using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a membership type.")]
        [Display(Name = "Select Membership Type")]
        public byte MembershipTypeId { get; set; }
        public List<SelectListItem> MembershipTypesListItems { get; set; }
        // public IEnumerable<GroupedSelectListItem> MembershipTypesListItems { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Customer" : "New Customer";
            }
        }

        public CustomerFormViewModel(List<MembershipType> membershipTypes)
        {
            Id = 0;

            PopulateMembershipTypes(membershipTypes);
        }

        public CustomerFormViewModel(Customer customer, List<MembershipType> membershipTypes)
        {
            Id = customer.Id;
            Name = customer.Name;
            MembershipTypeId = customer.MembershipTypeId;

            PopulateMembershipTypes(membershipTypes);
        }

        private void PopulateMembershipTypes(List<MembershipType> membershipTypes)
        {
            MembershipTypesListItems = new List<SelectListItem>();

            List<MembershipType> listOfGroups = membershipTypes
                .GroupBy(g => new { g.MembershipTypeGroup.Id })
                .Select(g => g.First())
                .ToList();

            List<SelectListGroup> selectListGroup = new List<SelectListGroup>();
            foreach(MembershipType group in listOfGroups)
            {
                selectListGroup.Add(new SelectListGroup { Name = group.MembershipTypeGroup.Name });
            }


            foreach (MembershipType membershipType in membershipTypes)
            {
                MembershipTypesListItems.Add(new SelectListItem
                {
                    Value = membershipType.Id.ToString(),
                    Text = membershipType.Name,
                    Group = selectListGroup.Single(g => g.Name == membershipType.MembershipTypeGroup.Name)
                });
            }
        }
    }
}