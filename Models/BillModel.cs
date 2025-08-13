using Microsoft.AspNetCore.Mvc;

namespace RetoFactus.Models
{
    public class BillsResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public Bills data { get; set; }
    }
    public class Bills 
    {
        public List<InfoBill> data { get; set; }
        public Pagination pagination { get; set; }
    }
    public class InfoBill
    {
        public int id { get; set; }
        public Document document { get; set; }
        public string number { get; set; }
        public string api_client_name { get; set; }
        public string reference_code { get; set; }
        public string identification { get; set; }
        public string graphic_representation_name { get; set; }
        public string? company {  get; set; }
        public string? trade_name { get; set; }
        public string names { get; set; }
        public string email { get; set; }
        public string total { get; set; }
        public int status { get; set; }
        public Dictionary <string, string> errors { get; set; }
        public int send_email { get; set; }
        public int has_claim { get; set; }
        public int is_negotiable_instrument { get; set; }
        public PaymentForm payment_form { get; set; }
        public string created_at { get; set; }
        public string[] credit_notes { get; set; }
        public string[] debit_notes { get; set; }
    }
    public class Document
    {
        public string code { get; set; }
        public string name { get; set; }
    }
    public class PaymentForm
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Pagination
    {
        public int total { get; set; }
        public int per_page { get; set; }
        public int current_page { get; set; }
        public int last_page { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public List<PaginationLink> links { get; set; }
    }

    public class PaginationLink
    {
        public string url { get; set; }
        public object label { get; set; }
        public bool active { get; set; }
        public int? page { get; set; }
    }
}

