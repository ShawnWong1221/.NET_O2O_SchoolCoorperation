﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserCompleteRequirement
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private User user = new User();

        public User User
        {
            get { return user; }
            set { user = value; }
        }
        private Requirement requirement = new Requirement();

        public Requirement Requirement
        {
            get { return requirement; }
            set { requirement = value; }
        }
        private DateTime completeTime;

        public DateTime CompleteTime
        {
            get { return completeTime; }
            set { completeTime = value; }
        }
    }
}
