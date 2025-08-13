namespace RetoFactus.Models
{
    public class DetailBillModel
    {
        public string document { get; set; }
        public string numbering_range_id { get; set; }
        public string reference_code { get; set; }
        public string observation { get; set; }
        public string payment_form { get; set; }
        public string payment_method_code { get; set; }
        public Customer customer { get; set; }
        public List<Items> items { get; set; }
    }
    public class Customer
    {
        public string identification { get; set; }
        public string dv { get; set; }
        public string company { get; set; }
        public string trade_name { get; set; }
        public string names { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string legal_organization_id { get; set; }
        public int tribute_id { get; set; }
        public int identification_document_id { get; set; }
        public string municipality_id { get; set; }
    }
    public class Items
    {
        public string code_reference { get; set; }
        public string name { get; set; }
        public decimal quantity { get; set; }
        public decimal discount_rate { get; set; }
        public int price { get; set; }
        public string tax_rate { get; set; }
        public int unit_measure_id { get; set; }
        public int standard_code_id { get; set; }
        public int is_excluded { get; set; }
        public int tribute_id { get; set; }
        public List<WithholdingTaxes> withholding_taxes { get; set; }
    }
    public class WithholdingTaxes
    {
        public string code { get; set; }
        public double withholding_tax_rate { get; set; }
    }
}

