/* Title:           Purchase Request Items Class
 * Date:            1-13-20
 * Author:          Terry Holmes
 * 
 * Description:     This class is used for the items for a purchase request */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace PurchaseRequestItemsDLL
{
    public class PurchaseRequestItemsClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        PurchaseRequestItemsDataSet aPurchaseRequestItemsDataSet;
        PurchaseRequestItemsDataSetTableAdapters.purchaserequestitemsTableAdapter aPurchaseRequestItemsTableAdapter;

        InsertPurchaseRequestItemEntryTableAdapters.QueriesTableAdapter aInsertPurchaseRequestItemTableAdapter;

        UpdatePurchaseRequestItemInformationEntryTableAdapters.QueriesTableAdapter aUpdatePurchaseRequestitemInformationTableAdapter;

        RemovePurchaseRequestItemEntryTableAdapters.QueriesTableAdapter aRemovePurchaseRequestItemTableAdapter;

        FindPurchaseRequestItemsByPONumberDataSet aFindPurchaseRequestItemsByPONumberDataSet;
        FindPurchaseRequestItemsByPONumberDataSetTableAdapters.FindPurchaseRequestItemsByPONumberTableAdapter aFindPurchaseRequestItemsByPONumberTableAdapter;

        public FindPurchaseRequestItemsByPONumberDataSet FindPurchaseRequestItemsByPONumber(int intPONumber)
        {
            try
            {
                aFindPurchaseRequestItemsByPONumberDataSet = new FindPurchaseRequestItemsByPONumberDataSet();
                aFindPurchaseRequestItemsByPONumberTableAdapter = new FindPurchaseRequestItemsByPONumberDataSetTableAdapters.FindPurchaseRequestItemsByPONumberTableAdapter();
                aFindPurchaseRequestItemsByPONumberTableAdapter.Fill(aFindPurchaseRequestItemsByPONumberDataSet.FindPurchaseRequestItemsByPONumber, intPONumber);
            }
            catch(Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Items Class // Find Purchase Request Items By PO Number " + Ex.Message);
            }

            return aFindPurchaseRequestItemsByPONumberDataSet;
        }
        public bool RemovePurchaseRequestItem(int intLineID)
        {
            bool blnFatalError = false;

            try
            {
                aRemovePurchaseRequestItemTableAdapter = new RemovePurchaseRequestItemEntryTableAdapters.QueriesTableAdapter();
                aRemovePurchaseRequestItemTableAdapter.RemovePurchaseRequestItem(intLineID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Items Class // Remove Purchase Request Item " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool UpdatePurchaseRequestItemInformation(int intLineID, int intQuantity, decimal decPricePerUnit, decimal decTotalPrice)
        {
            bool blnFatalError = false;

            try
            {
                aUpdatePurchaseRequestitemInformationTableAdapter = new UpdatePurchaseRequestItemInformationEntryTableAdapters.QueriesTableAdapter();
                aUpdatePurchaseRequestitemInformationTableAdapter.UpdatePurchaseRequestItemInformation(intLineID, intQuantity, decPricePerUnit, decTotalPrice);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Items Class // Update Purchase Request Item Information " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertPurchaseRequestItem(int intPONumber, int intQuantity, string strVendorPartNo, string strDescription, int intPartID, decimal decPricePerUnit, int intItemTypeID, decimal decTotalPrice)
        {
            bool blnFatalError = false;

            try
            {
                aInsertPurchaseRequestItemTableAdapter = new InsertPurchaseRequestItemEntryTableAdapters.QueriesTableAdapter();
                aInsertPurchaseRequestItemTableAdapter.InsertPurchaseRequestItem(intPONumber, intQuantity, strVendorPartNo, strDescription, intPartID, decPricePerUnit, intItemTypeID, decTotalPrice);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Items Class // Insert Purchase Request Item " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public PurchaseRequestItemsDataSet GetPurchaseRequestItemsInfo()
        {
            try
            {
                aPurchaseRequestItemsDataSet = new PurchaseRequestItemsDataSet();
                aPurchaseRequestItemsTableAdapter = new PurchaseRequestItemsDataSetTableAdapters.purchaserequestitemsTableAdapter();
                aPurchaseRequestItemsTableAdapter.Fill(aPurchaseRequestItemsDataSet.purchaserequestitems);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Items Class // Get Purchase Request Items Info " + Ex.Message);
            }

            return aPurchaseRequestItemsDataSet;
        }
        public void UpdatePurchaseReqeustItemsDB(PurchaseRequestItemsDataSet aPurchaseRequestItemsDataSet)
        {
            try
            {
                aPurchaseRequestItemsTableAdapter = new PurchaseRequestItemsDataSetTableAdapters.purchaserequestitemsTableAdapter();
                aPurchaseRequestItemsTableAdapter.Update(aPurchaseRequestItemsDataSet.purchaserequestitems);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Items Class // Update Purchase Request Items DB " + Ex.Message);
            }
        }
    }
}
