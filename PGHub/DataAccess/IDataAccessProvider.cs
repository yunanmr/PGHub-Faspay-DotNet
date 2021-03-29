using PGHub.Entity;
using System.Collections.Generic;

namespace PGHub.DataAccess
{
    public interface IDataAccessProvider
    {
        // Payments
        Payment GetPaymentSingleRecord(string code);
        List<Payment> GetPaymentRecords();

        // Transaction
        void AddTransactionRecord(Transaction transaction);
        Transaction GetTransactionSingleRecord(string trx_id);
        Transaction GetTransactionByBill(string bill_no);
        Transaction GetTransactionByVA(string va_number);
    }
}
