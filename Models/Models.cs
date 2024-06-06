using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class pw_users
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(256)]
        public string email { get; set; }

        [Required]
        [MaxLength(256)]
        public string password { get; set; }

        [MaxLength(2048)]
        public string name { get; set; }

        public decimal balance { get; set; }

    }


    public class PaymentRequest
    {
        [Required]
        public string ClientReferenceInformationCode { get; set; }

        [Required]
        public bool ProcessingInformationCapture { get; set; }

        [Required]
        public string PaymentInformationCardNumber { get; set; }

        [Required]
        public string PaymentInformationCardExpirationMonth { get; set; }

        [Required]
        public string PaymentInformationCardExpirationYear { get; set; }

        [Required]
        public string OrderInformationAmountDetailsTotalAmount { get; set; }

        [Required]
        public string OrderInformationAmountDetailsCurrency { get; set; }

        [Required]
        public string OrderInformationBillToFirstName { get; set; }

        [Required]
        public string OrderInformationBillToLastName { get; set; }

        [Required]
        public string OrderInformationBillToAddress1 { get; set; }

        [Required]
        public string OrderInformationBillToLocality { get; set; }

        [Required]
        public string OrderInformationBillToAdministrativeArea { get; set; }

        [Required]
        public string OrderInformationBillToPostalCode { get; set; }

        [Required]
        public string OrderInformationBillToCountry { get; set; }

        [Required]
        public string OrderInformationBillToEmail { get; set; }

        [Required]
        public string OrderInformationBillToPhoneNumber { get; set; }
    }
}
