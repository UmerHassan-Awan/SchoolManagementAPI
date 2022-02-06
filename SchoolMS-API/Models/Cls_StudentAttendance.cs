using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_StudentAttendance
    {
        #region Objects
        #endregion

        #region Private Variables

        private int _AttendanceID;
        private int _ClassID;
        private int _SectionID;
        private int _StudentID;
        private DateTime? _DateEntered;
        private TimeSpan _TimeIN;
        private TimeSpan _TimeOUT;
        private string _Status;
        private string _Remarks;

        #endregion

        #region Public Properties
        
        
        public int AttendanceID { get { return _AttendanceID; } set { _AttendanceID = value; } }

        
        public int ClassID { get { return _ClassID; } set { _ClassID = value; } }

        
        public int SectionID { get { return _SectionID; } set { _SectionID = value; } }

        
        public int StudentID { get { return _StudentID; } set { _StudentID = value; } }

        
        public DateTime? DateEntered { get { return _DateEntered; } set { _DateEntered = value; } }

        
        public TimeSpan TimeIN { get { return _TimeIN; } set { _TimeIN = value; } }

        
        public TimeSpan TimeOUT { get { return _TimeOUT; } set { _TimeOUT = value; } }

        
        public string Status { get { return _Status; } set { _Status = value; } }

        
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }

        #endregion

        #region DML Methods
        #endregion

        #region DDL Methods
        #endregion

        #region Private Methods
        #endregion
    }
}