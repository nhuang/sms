DROP TABLE Definition;
CREATE TABLE Definition (definitionId INT NOT NULL IDENTITY, displayName NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, keyName NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, keyValue NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, keyGroup NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, sequence INT, CONSTRAINT PK_DEFINITION PRIMARY KEY (definitionId));
INSERT INTO Definition (definitionId, displayName, keyName, keyValue, keyGroup, sequence) VALUES (1, 'Alberta', 'Alberta', 'Alberta', 'Province', 1);
INSERT INTO Definition (definitionId, displayName, keyName, keyValue, keyGroup, sequence) VALUES (2, 'Beer', 'Beer', 'Beer', 'Team', 1);
INSERT INTO Definition (definitionId, displayName, keyName, keyValue, keyGroup, sequence) VALUES (3, 'Male', 'Male', 'Male', 'Gender', 1);
INSERT INTO Definition (definitionId, displayName, keyName, keyValue, keyGroup, sequence) VALUES (4, 'Female', 'Female', 'Female', 'Gender', 1);
INSERT INTO Definition (definitionId, displayName, keyName, keyValue, keyGroup, sequence) VALUES (5, 'Activate', 'Activate', 'Activate', 'ActiviteStatus', 1);
INSERT INTO Definition (definitionId, displayName, keyName, keyValue, keyGroup, sequence) VALUES (6, 'Home', 'Home', 'Home', 'LocationType', 1);
INSERT INTO Definition (definitionId, displayName, keyName, keyValue, keyGroup, sequence) VALUES (7, 'Family', 'Family', 'Family', 'ContactReleationship', 1);
INSERT INTO Definition (definitionId, displayName, keyName, keyValue, keyGroup, sequence) VALUES (8, 'Friend', 'Friend', 'Friend', 'ContactReleationship', 1);
INSERT INTO Definition (definitionId, displayName, keyName, keyValue, keyGroup, sequence) VALUES (9, 'BucksPerShift', 'BucksPerShift', '5', 'Setting', 1);
INSERT INTO Definition (definitionId, displayName, keyName, keyValue, keyGroup, sequence) VALUES (1002, 'Agents', 'Agents', 'Agents', 'Team', 1);
DROP TABLE EmergencyContact;
CREATE TABLE EmergencyContact (contactId INT NOT NULL IDENTITY, volunteerId INT, firstName NVARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, lastName NVARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, relationship NVARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, primaryPhone NVARCHAR(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, otherPhone NVARCHAR(20) COLLATE SQL_Latin1_General_CP1_CI_AS, CONSTRAINT PK_EMERGENCYCONTACT PRIMARY KEY (contactId));
INSERT INTO EmergencyContact (contactId, volunteerId, firstName, lastName, relationship, primaryPhone, otherPhone) VALUES (1, 2, 'Noah', 'Huang', 'Family', '12312312', '3123123213');
DROP TABLE Location;
CREATE TABLE Location (locationId INT NOT NULL IDENTITY, volunteerId INT, contactId INT, description NVARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS, address NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS, city NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS, province NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS, country NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS, postalcode NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS, CONSTRAINT PK_LOCATION PRIMARY KEY (locationId));
INSERT INTO Location (locationId, volunteerId, contactId, description, address, city, province, country, postalcode) VALUES (1, 1, null, null, '31213123', 'Ed', null, 'Canada', '2342424');
INSERT INTO Location (locationId, volunteerId, contactId, description, address, city, province, country, postalcode) VALUES (2, 2, null, 'Home', '31321 fafsad', 'fafd', 'Alberta', 'Canada', '243242');
DROP TABLE ShiftRecord;
CREATE TABLE ShiftRecord (volunteerId INT, recordId INT NOT NULL IDENTITY, teamName NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS, startOn DATETIME NOT NULL, endOn DATETIME, createOn DATETIME NOT NULL, createBy NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, modifiedOn DATETIME NOT NULL, modifiedBy NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, earnedBucks NUMERIC(10,2) NOT NULL, CONSTRAINT PK_SHIFTRECORD PRIMARY KEY (recordId));
INSERT INTO ShiftRecord (volunteerId, recordId, teamName, startOn, endOn, createOn, createBy, modifiedOn, modifiedBy, earnedBucks) VALUES (1, 1, 'Beer', '2013-02-12 23:25:00', '2013-02-13 01:04:00', '2013-02-12 23:25:29', 'admin', '2013-02-13 01:04:10', 'admin', 4.00);
INSERT INTO ShiftRecord (volunteerId, recordId, teamName, startOn, endOn, createOn, createBy, modifiedOn, modifiedBy, earnedBucks) VALUES (2, 2, 'Beer', '2013-02-13 00:31:00', '2013-02-13 00:34:00', '2013-02-13 00:32:04', 'admin', '2013-02-13 00:34:37', 'admin', 4.00);
INSERT INTO ShiftRecord (volunteerId, recordId, teamName, startOn, endOn, createOn, createBy, modifiedOn, modifiedBy, earnedBucks) VALUES (1, 3, 'Beer', '2013-02-13 01:03:00', '2013-02-13 03:30:00', '2013-02-13 01:04:14', 'admin', '2013-02-13 01:04:41', 'admin', 4.00);
INSERT INTO ShiftRecord (volunteerId, recordId, teamName, startOn, endOn, createOn, createBy, modifiedOn, modifiedBy, earnedBucks) VALUES (1, 4, 'Beer', '2013-02-13 01:04:00', '2013-02-13 00:30:00', '2013-02-13 01:04:17', 'admin', '2013-02-13 01:04:32', 'admin', 4.00);
INSERT INTO ShiftRecord (volunteerId, recordId, teamName, startOn, endOn, createOn, createBy, modifiedOn, modifiedBy, earnedBucks) VALUES (2, 1002, 'Beer', '2013-02-13 17:23:00', '2013-02-13 00:30:00', '2013-02-13 17:23:57', 'admin', '2013-02-13 17:24:21', 'admin', 4.00);
INSERT INTO ShiftRecord (volunteerId, recordId, teamName, startOn, endOn, createOn, createBy, modifiedOn, modifiedBy, earnedBucks) VALUES (1, 1003, 'Agents', '2013-02-13 17:37:00', '2013-02-13 17:43:00', '2013-02-13 17:37:54', 'admin', '2013-02-13 17:43:43', 'admin', 5.00);
DROP TABLE UserProfile;
CREATE TABLE UserProfile (UserId INT NOT NULL IDENTITY, UserName NVARCHAR(56) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, Email NVARCHAR(256) COLLATE SQL_Latin1_General_CP1_CI_AS, Phone NVARCHAR(20) COLLATE SQL_Latin1_General_CP1_CI_AS, FullName NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS, Administrator BIT DEFAULT 0, Coordinator BIT DEFAULT 1, PRIMARY KEY (UserId), UNIQUE (UserName));
INSERT INTO UserProfile (UserId, UserName, Email, Phone, FullName, Administrator, Coordinator) VALUES (1, 'admin', 'huangnoah@gmail.com', '(780) 267-8688', 'Noah Huang', true, true);
DROP TABLE Volunteer;
CREATE TABLE Volunteer (volunteerId INT NOT NULL IDENTITY, firstName NVARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, lastName NVARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, nickName NVARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS, birthday DATE, status NVARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS, gender NVARCHAR(20) COLLATE SQL_Latin1_General_CP1_CI_AS, primaryPhone NVARCHAR(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, otherPhone NVARCHAR(20) COLLATE SQL_Latin1_General_CP1_CI_AS, createOn DATETIME NOT NULL, createBy NVARCHAR(256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, modifiedOn DATETIME NOT NULL, modifiedBy NVARCHAR(256) COLLATE SQL_Latin1_General_CP1_CI_AS, activatedOn DATETIME, deactivatedOn DATETIME, note NVARCHAR(4000) COLLATE SQL_Latin1_General_CP1_CI_AS, token NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS, CONSTRAINT PK_VOLUNTEER PRIMARY KEY (volunteerId));
INSERT INTO Volunteer (volunteerId, firstName, lastName, nickName, birthday, status, gender, primaryPhone, otherPhone, createOn, createBy, modifiedOn, modifiedBy, activatedOn, deactivatedOn, note, token) VALUES (1, 'Hank', 'Huang', 'Hankie', '1993-02-12', 'Activate', 'Male', '(780) 267-8688', '(312) 312-3123', '2013-02-12 23:21:09', 'admin', '2013-02-13 01:02:57', 'admin', '2013-02-12 00:00:00', null, '', '130052100694180012');
INSERT INTO Volunteer (volunteerId, firstName, lastName, nickName, birthday, status, gender, primaryPhone, otherPhone, createOn, createBy, modifiedOn, modifiedBy, activatedOn, deactivatedOn, note, token) VALUES (2, 'Ann', 'Huang', 'Ann', '1993-02-13', 'Activate', 'Female', '(987) 654-3244', '(132) 123-1231', '2013-02-13 00:31:54', 'admin', '2013-02-13 01:03:21', 'admin', '2013-02-13 00:00:00', null, null, '130052143144503449');
DROP TABLE webpages_Membership;
CREATE TABLE webpages_Membership (UserId INT NOT NULL, CreateDate DATETIME, ConfirmationToken SYSNAME COLLATE SQL_Latin1_General_CP1_CI_AS, IsConfirmed BIT DEFAULT 0, LastPasswordFailureDate DATETIME, PasswordFailuresSinceLastSuccess INT DEFAULT 0 NOT NULL, Password SYSNAME COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, PasswordChangedDate DATETIME, PasswordSalt SYSNAME COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, PasswordVerificationToken SYSNAME COLLATE SQL_Latin1_General_CP1_CI_AS, PasswordVerificationTokenExpirationDate DATETIME, PRIMARY KEY (UserId));
INSERT INTO webpages_Membership (UserId, CreateDate, ConfirmationToken, IsConfirmed, LastPasswordFailureDate, PasswordFailuresSinceLastSuccess, Password, PasswordChangedDate, PasswordSalt, PasswordVerificationToken, PasswordVerificationTokenExpirationDate) VALUES (1, '2013-02-13 06:18:18', null, true, null, 0, 'ALZIkXoTD9VyHxO8Rz4G597/4pBVvdwPCrkpjuhBHRyIOyFw3QJYwo7ZZP/AGxMnfQ==', '2013-02-13 06:18:18', '', null, null);
DROP TABLE webpages_OAuthMembership;
CREATE TABLE webpages_OAuthMembership (Provider NVARCHAR(30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, ProviderUserId NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, UserId INT NOT NULL, PRIMARY KEY (Provider, ProviderUserId));
DROP TABLE webpages_Roles;
CREATE TABLE webpages_Roles (RoleId INT NOT NULL IDENTITY, RoleName NVARCHAR(256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, PRIMARY KEY (RoleId), UNIQUE (RoleName));
INSERT INTO webpages_Roles (RoleId, RoleName) VALUES (1, 'Administrator');
INSERT INTO webpages_Roles (RoleId, RoleName) VALUES (2, 'Coordinator');
DROP TABLE webpages_UsersInRoles;
CREATE TABLE webpages_UsersInRoles (UserId INT NOT NULL, RoleId INT NOT NULL, PRIMARY KEY (UserId, RoleId));
INSERT INTO webpages_UsersInRoles (UserId, RoleId) VALUES (1, 1);
INSERT INTO webpages_UsersInRoles (UserId, RoleId) VALUES (1, 2);
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (3, 'sqlserver', 'database_id');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (4, 'sqlserver', 'transaction_id');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (5, 'sqlserver', 'tsql_frame');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (6, 'sqlserver', 'nt_username');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (7, 'sqlserver', 'nt_username');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (8, 'sqlserver', 'client_hostname');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (9, 'sqlserver', 'client_pid');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (10, 'sqlserver', 'client_app_name');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (11, 'sqlserver', 'server_principal_name');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (12, 'sqlserver', 'session_id');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (26, 'sqlserver', 'server_instance_name');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (35, 'sqlserver', 'database_name');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (41, 'sqlserver', 'server_principal_sid');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (49, 'sqlserver', 'request_id');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (50, 'sqlserver', 'transaction_sequence');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (51, 'package0', 'event_sequence');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (60, 'sqlserver', 'is_system');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (61, 'sqlserver', 'tsql_frame');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (63, 'sqlserver', 'tsql_frame');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (64, 'sqlserver', 'session_server_principal_name');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (65, 'sqlserver', 'plan_handle');
INSERT INTO trace_xe_action_map (trace_column_id, package_name, xe_action_name) VALUES (66, 'sqlserver', 'session_resource_group_id');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (10, 'sqlserver', 'rpc_completed');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (11, 'sqlserver', 'rpc_starting');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (12, 'sqlserver', 'sql_batch_completed');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (13, 'sqlserver', 'sql_batch_starting');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (14, 'sqlserver', 'login');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (15, 'sqlserver', 'logout');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (16, 'sqlserver', 'attention');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (17, 'sqlserver', 'existing_connection');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (18, 'sqlserver', 'server_start_stop');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (19, 'sqlserver', 'dtc_transaction');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (21, 'sqlserver', 'error_reported');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (22, 'sqlserver', 'errorlog_written');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (23, 'sqlserver', 'lock_released');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (24, 'sqlserver', 'lock_acquired');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (25, 'sqlserver', 'lock_deadlock');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (26, 'sqlserver', 'lock_cancel');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (27, 'sqlserver', 'lock_timeout');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (28, 'sqlserver', 'degree_of_parallelism');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (33, 'sqlos', 'exception_ring_buffer_recorded');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (34, 'sqlserver', 'sp_cache_miss');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (35, 'sqlserver', 'sp_cache_insert');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (36, 'sqlserver', 'sp_cache_remove');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (37, 'sqlserver', 'sql_statement_recompile');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (38, 'sqlserver', 'sp_cache_hit');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (40, 'sqlserver', 'sql_statement_starting');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (41, 'sqlserver', 'sql_statement_completed');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (42, 'sqlserver', 'module_start');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (43, 'sqlserver', 'module_end');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (44, 'sqlserver', 'sp_statement_starting');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (45, 'sqlserver', 'sp_statement_completed');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (46, 'sqlserver', 'object_created');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (47, 'sqlserver', 'object_deleted');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (50, 'sqlserver', 'sql_transaction');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (51, 'sqlserver', 'scan_started');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (52, 'sqlserver', 'scan_stopped');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (53, 'sqlserver', 'cursor_open');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (54, 'sqlserver', 'transaction_log');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (55, 'sqlserver', 'hash_warning');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (58, 'sqlserver', 'auto_stats');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (59, 'sqlserver', 'lock_deadlock_chain');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (60, 'sqlserver', 'lock_escalation');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (61, 'sqlserver', 'oledb_error');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (67, 'sqlserver', 'execution_warning');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (68, 'sqlserver', 'query_pre_execution_showplan');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (69, 'sqlserver', 'sort_warning');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (70, 'sqlserver', 'cursor_prepare');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (71, 'sqlserver', 'prepare_sql');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (72, 'sqlserver', 'exec_prepared_sql');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (73, 'sqlserver', 'unprepare_sql');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (74, 'sqlserver', 'cursor_execute');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (75, 'sqlserver', 'cursor_recompile');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (76, 'sqlserver', 'cursor_implicit_conversion');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (77, 'sqlserver', 'cursor_unprepare');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (78, 'sqlserver', 'cursor_close');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (79, 'sqlserver', 'missing_column_statistics');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (80, 'sqlserver', 'missing_join_predicate');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (81, 'sqlserver', 'server_memory_change');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (82, 'sqlserver', 'user_event');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (83, 'sqlserver', 'user_event');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (84, 'sqlserver', 'user_event');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (85, 'sqlserver', 'user_event');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (86, 'sqlserver', 'user_event');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (87, 'sqlserver', 'user_event');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (88, 'sqlserver', 'user_event');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (89, 'sqlserver', 'user_event');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (90, 'sqlserver', 'user_event');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (91, 'sqlserver', 'user_event');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (92, 'sqlserver', 'database_file_size_change');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (93, 'sqlserver', 'database_file_size_change');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (94, 'sqlserver', 'database_file_size_change');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (95, 'sqlserver', 'database_file_size_change');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (96, 'sqlserver', 'query_pre_execution_showplan');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (97, 'sqlserver', 'query_pre_execution_showplan');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (98, 'sqlserver', 'query_post_execution_showplan');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (100, 'sqlserver', 'rpc_completed');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (119, 'sqlserver', 'oledb_call');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (120, 'sqlserver', 'oledb_query_interface');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (121, 'sqlserver', 'oledb_data_read');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (122, 'sqlserver', 'query_pre_execution_showplan');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (124, 'sqlserver', 'broker_conversation');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (125, 'sqlserver', 'deprecation_announcement');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (126, 'sqlserver', 'deprecation_final_support');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (127, 'sqlserver', 'exchange_spill');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (136, 'sqlserver', 'broker_conversation_group');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (137, 'sqlserver', 'blocked_process_report');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (138, 'ucs', 'ucs_connection_setup');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (139, 'sqlserver', 'broker_forwarded_message_sent');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (140, 'sqlserver', 'broker_forwarded_message_dropped');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (141, 'sqlserver', 'broker_message_classify');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (142, 'sqlserver', 'broker_transmission_exception');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (143, 'sqlserver', 'broker_queue_disabled');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (144, 'sqlserver', 'broker_mirrored_route_state_changed');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (146, 'sqlserver', 'query_post_execution_showplan');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (148, 'sqlserver', 'xml_deadlock_report');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (149, 'sqlserver', 'broker_remote_message_acknowledgement');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (151, 'ucs', 'ucs_connection_setup');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (155, 'sqlserver', 'full_text_crawl_started');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (156, 'sqlserver', 'full_text_crawl_stopped');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (157, 'sqlserver', 'error_reported');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (160, 'sqlserver', 'broker_message_undeliverable');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (161, 'sqlserver', 'broker_corrupted_message');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (162, 'sqlserver', 'error_reported');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (163, 'sqlserver', 'broker_activation');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (164, 'sqlserver', 'object_altered');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (165, 'sqlserver', 'query_cache_removal_statistics');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (165, 'sqlserver', 'query_pre_execution_showplan');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (165, 'sqlserver', 'uncached_sql_batch_statistics');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (166, 'sqlserver', 'sql_statement_recompile');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (167, 'sqlserver', 'database_mirroring_state_change');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (168, 'sqlserver', 'query_post_compilation_showplan');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (169, 'sqlserver', 'query_post_compilation_showplan');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (181, 'sqlserver', 'begin_tran_starting');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (182, 'sqlserver', 'begin_tran_completed');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (183, 'sqlserver', 'promote_tran_starting');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (184, 'sqlserver', 'promote_tran_completed');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (185, 'sqlserver', 'commit_tran_starting');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (186, 'sqlserver', 'commit_tran_completed');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (187, 'sqlserver', 'rollback_tran_starting');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (188, 'sqlserver', 'rollback_tran_completed');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (189, 'sqlserver', 'lock_timeout_greater_than_0');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (190, 'sqlserver', 'progress_report_online_index_operation');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (191, 'sqlserver', 'save_tran_starting');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (192, 'sqlserver', 'save_tran_completed');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (193, 'sqlserver', 'background_job_error');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (194, 'sqlserver', 'oledb_provider_information');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (196, 'sqlserver', 'assembly_load');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (198, 'sqlserver', 'xquery_static_type');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (199, 'sqlserver', 'qn_subscription');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (200, 'sqlserver', 'qn_parameter_table');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (201, 'sqlserver', 'qn_template');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (202, 'sqlserver', 'qn_dynamics');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (212, 'sqlserver', 'bitmap_disabled_warning');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (213, 'sqlserver', 'database_suspect_data_page');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (214, 'sqlserver', 'cpu_threshold_exceeded');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (215, 'sqlserver', 'preconnect_starting');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (216, 'sqlserver', 'preconnect_completed');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (217, 'sqlserver', 'plan_guide_successful');
INSERT INTO trace_xe_event_map (trace_event_id, package_name, xe_event_name) VALUES (218, 'sqlserver', 'plan_guide_unsuccessful');
ALTER TABLE EmergencyContact ADD CONSTRAINT FK_EMERGENC_REFERENCE_VOLUNTEE FOREIGN KEY (volunteerId) REFERENCES Volunteer (volunteerId);
ALTER TABLE Location ADD CONSTRAINT FK_LOCATION_REFERENCE_VOLUNTEE FOREIGN KEY (volunteerId) REFERENCES Volunteer (volunteerId);
ALTER TABLE Location ADD CONSTRAINT FK_LOCATION_REFERENCE_EMERGENC FOREIGN KEY (contactId) REFERENCES EmergencyContact (contactId);
ALTER TABLE ShiftRecord ADD CONSTRAINT FK_SHIFTREC_RECORDS_VOLUNTEE FOREIGN KEY (volunteerId) REFERENCES Volunteer (volunteerId);
ALTER TABLE webpages_OAuthMembership ADD CONSTRAINT FK_WEBPAGES_REFERENCE_USERPROF FOREIGN KEY (UserId) REFERENCES UserProfile (UserId);
ALTER TABLE webpages_UsersInRoles ADD CONSTRAINT fk_RoleId FOREIGN KEY (RoleId) REFERENCES webpages_Roles (RoleId);
ALTER TABLE webpages_UsersInRoles ADD CONSTRAINT fk_UserId FOREIGN KEY (UserId) REFERENCES UserProfile (UserId);