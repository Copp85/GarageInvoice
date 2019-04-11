using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInVoice
{
    class ServiceInvoice
    {
        //constants
        private const int LABOUR_CHARGE = 45;
        private const decimal PARTS_VAT = .135m;
        private const decimal LABOUR_VAT = .215M;
        private const decimal DISCOUNT_APPLIED = .05M;

        #region properties
        public string Name { get; set; }
        public string Registration { get; set; }
        public int Odometer { get; set; }
        public int Labour { get; set; }
        public int CostofParts { get; set; }
        #endregion properties

        #region Constructors
        public ServiceInvoice()
        {

        }

        public ServiceInvoice(string aName, string aReg, int mileage, int workDone, int parts)
        {
            Name = aName;
            Registration = aReg;
            Odometer = mileage;
            Labour = workDone;
            CostofParts = parts;
        }

        public ServiceInvoice(string aName, string aReg)
        {
            Name = aName;
            Registration = aReg;
            Odometer = 0;
            Labour = 0;
            CostofParts = 0;
        }
        #endregion Constructors

        //Get charge for labour
        public int GetLabourCharge()
        {
            return Labour * LABOUR_CHARGE;
        }

        //Get VAT for parts
        public decimal GetVatOfParts()
        {
            return CostofParts * PARTS_VAT;
        }

        //Get VAT for labour
        public decimal GetVatOfLabour()
        {
            return GetLabourCharge() * LABOUR_VAT;
        }

        //Get Gross
        public decimal GetGross()
        {
            return GetLabourCharge() + CostofParts;
        }

        //Get subtotal
        public decimal GetSubTotal()
        {
           return GetLabourCharge() + GetVatOfLabour() + CostofParts + GetVatOfParts();
        }

        //Check for discount
        public decimal GetDiscount()
        {
            decimal discount = 0;
            if (GetSubTotal()> 100)
            {
                //decimal discount =0;
                discount = GetSubTotal() * DISCOUNT_APPLIED;
                
            }
            return discount;
        }

        //Get total
        public decimal GetTotal()
        {
            return GetSubTotal() - GetDiscount();
        }

        //Output string representation
        public override string ToString()
        {
            return string.Format ("Date: 24/11/18" +
                "\nName: {0}" +
                "\nVehicle registration: {1}"  +
                "\nMileage: {2}" +
                "\n\n_______________________________" +
                "\nDescription               Cost" +
                "\n----------            -----------" +
                "\nLabour: {3:C}" +
                "\nParts: {4:C}" +
                "\n" +
                "\nGross: {5:C}" +
                "\nVAT on Parts: {6:C}" +
                "\nVAT on Labour: {7:C}" +
                "\n" +
                "\nsub total: {8:C}" +
                "\nDiscount: {9:C}" +
                "\n" +
                "Total: {10:C}", Name, Registration, Odometer, GetLabourCharge(), CostofParts, GetGross(), GetVatOfParts(), +
                GetVatOfLabour(), GetSubTotal(), GetDiscount(), GetTotal() );
        }
    }
}
