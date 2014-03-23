use FVTS;

delete ShiftRecord;
delete Location;
delete EmergencyContact;
delete Volunteer;
delete webpages_Membership where UserId !=1;
delete UserProfile where UserId !=1;
delete webpages_UsersInRoles where UserId !=1;
