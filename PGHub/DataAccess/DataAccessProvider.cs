using Microsoft.EntityFrameworkCore;
using PGHub.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PGHub.DataAccess
{
    public class DataAccessProvider: IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        // Payment
        public Payment GetPaymentSingleRecord(string code)
        {
            return _context.payments.FirstOrDefault(t => t.code == code);
        }

        public List<Payment> GetPaymentRecords()
        {
            return _context.payments.ToList();
        }

        // Transaction
        public void AddTransactionRecord(Transaction transaction)
        {
            _context.transactions.Add(transaction);
            _context.SaveChanges();
        }

        public Transaction GetTransactionSingleRecord(string trx_id)
        {
            return _context.transactions.FirstOrDefault(t => t.trx_id == trx_id);
        }
        public Transaction GetTransactionByBill(string bill_no)
        {
            return _context.transactions.FirstOrDefault(t => t.bill_no == bill_no);
        }
        public Transaction GetTransactionByVA(string va_number)
        {
            return _context.transactions.FirstOrDefault(t => t.va_number == va_number);
        }
    }
}
