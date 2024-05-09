
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechnoTitansFinal.Models;
//using ThreadNetwork;

namespace TechnoTitansFinal.Services
{

    public class LocalDb
    {

        public SQLiteConnection _dbConnection;

        public string GetDataBasePath()
        {
            string filename = "LocalDb.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return pathToDb + filename;
        }


        public LocalDb()
        {
            _dbConnection = new SQLiteConnection(GetDataBasePath());

            _dbConnection.CreateTable<User>(); //Created a dummy user
            _dbConnection.CreateTable<Sport>(); //Completed
            _dbConnection.CreateTable<UserType>(); //Completed
            _dbConnection.CreateTable<Club>(); //Created a dummy club
            _dbConnection.CreateTable<BodyPart>(); //Created some dummy body parts
            _dbConnection.CreateTable<AddressLocation>(); //Craeted a dummy location
            _dbConnection.CreateTable<ProviderInjury>(); //K //Done Seeding
            _dbConnection.CreateTable<Provider>(); //K //created a dummy provider
            _dbConnection.CreateTable<ServiceType>(); //Created a dummy service type
            _dbConnection.CreateTable<Treatment>(); //K? //Done Seeding
            //_dbConnection.CreateTable<TreatmentAction>(); //K //done seeding
            _dbConnection.CreateTable<TreatmentDashboard>(); //K //Need help on displaying the data
            _dbConnection.CreateTable<TreatmentFrequency>(); //K //Done Seeding
            _dbConnection.CreateTable<TreatmentType>(); //Created a dummy treatment type //

            SeedClient();
        }

        TreatmentAction? action;
        TreatmentFrequency? frequency;
        public List<string> sports = new List<string> { "Cricket", "Soccer", "Netball", "Athletics", "Rugby" };
        public List<string> bodyParts = new List<string> { "Ankle", "Wrist", "Neck", "Back", "Knee" };
        public void SeedClient()
        {

            if (_dbConnection.Table<BodyPart>().Count() == 0)
            {
                foreach (var x in bodyParts)
                {
                    BodyPart bodyPart = new()
                    { bodyPartName = x, bodyPartDescription = $"It's the {x}" };
                    _dbConnection.Insert(bodyPart);
                }
            }

            if (_dbConnection.Table<Sport>().Count() < sports.Count)
            {
                foreach (var x in sports)
                {
                    Sport sport = new()
                    {
                        sportName = x,
                        sportDescription = $"It's {x}"
                    };
                    _dbConnection.Insert(sport);
                }
            }

            if (_dbConnection.Table<TreatmentType>().Count()==0) 
            {
                TreatmentType type = new()
                {
                    treatmentTypeName = "Current Treatment", 
                    treatmentTypeDescription = "Treatment to follow during Rehabilitation",
                };
                _dbConnection.Insert(type);

                type = new()
                {
                    treatmentTypeName = "Post Treatment", 
                    treatmentTypeDescription = "Treatment to follow after Rehabilitation, to recover and strengthen the damaged area",
                };
            
                _dbConnection.Insert(type);
            }

            if (_dbConnection.Table<UserType>().Count() == 0)
            {
                UserType userType = new()
                {
                    userTypeName = "Athlete",
                    userTypeDetails = "Is Athlete",
                    isCoach = false
                };
                _dbConnection.Insert(userType);

                userType = new()
                {
                    userTypeName = "Coach",
                    userTypeDetails = "Is Coach",
                    isCoach = true
                };
                _dbConnection.Insert(userType);
            }

            if (_dbConnection.Table<ServiceType>().Count() == 0)
            {
                ServiceType service = new()
                {
                    serviceTypeName = "Physio-therapy", serviceTypeDescription = "It's type 1"
                };
                _dbConnection.Insert(service);
            }

            if (_dbConnection.Table<AddressLocation>().Count() == 0)
            {
                AddressLocation location = new()
                {
                    locationBuildingNumber = 1, 
                    locationUnitNumber = 1, 
                    locationStreetNumber = 1, 
                    locationStreetName = "One Street", 
                    locationSuburb = "The Burb", 
                    locationTown = "Townsville", 
                    locationProvince = "Western Cape", 
                    locationZipCode = "4321"
                };
                _dbConnection.Insert(location);
            }

            if (_dbConnection.Table<Club>().Count() == 0)
            {    
                Club club = new()
                {
                    clubName = "Cape Town Soccer", 
                    clubDescription = "Soccer club In The Heart Of Cape Town", 
                    clubLocation = 1,
                };
                _dbConnection.Insert(club);
            }
            
            if (_dbConnection.Table<User>().Count() == 0)
            {
                User user = new()
                {
                    userName = "John", 
                    userSurname = "Doe", 
                    userGender = "Male", 
                    userPhoneNumber = "0115551234", 
                    userEmail = "email@website.com", 
                    userDateOfBirth = new DateTime(1970,01,01), 
                    userPassword = "Pa$$word1!",
                    userType = 1, 
                    userClub = 1
                };
                _dbConnection.Insert(user);
            }

            if (_dbConnection.Table<ProviderInjury>().Count() == 0)
            {

                Provider provider = new()
                {
                    serviceProviderCompanyName = "Lyno Therapy",
                    serviceProviderPractitionerName = "Jane",
                    serviceProviderPractitionerSurname = "Doe",
                    serviceProviderPractitionerEmail = "jane.lyno@outlook.com",
                    serviceProviderPractitionerPhoneNumber = "0115551234",
                };
                _dbConnection.Insert(provider);

                Treatment treatment = new()
                {
                    treatmentName = "Sprained ankle Treatment",
                    treatmentDescription = "It 2 day treatment plan that will help you recover and heal the sprained ankle",
                    treatmentType = 1,
                    treatmentAction = 1
                };

                _dbConnection.Insert(treatment);
                AddTreatmentToProvider(provider, treatment);


                ProviderInjury injury = new()
                {
                    providerInjuryName = "Sprained Ankle",
                    providerInjuryDescription = "A sprained ankle is an injury that occurs when you roll, twist or turn your ankle in an awkward way. This can stretch or tear the tough bands of tissue (ligaments) that help hold your ankle bones together.",
                    providerInjuryBodyPart = 1
                };
                _dbConnection.Insert(injury);
                AddInjuryToProviderAndTreatment(provider, treatment, injury);

                treatment = new()
                {
                    treatmentName = "Broken Wrist Treatment",
                    treatmentDescription = "It 3 day treatment plan that will help you recover and heal the broken wrist",
                    treatmentType = 1,
                    treatmentAction = 2

                };
                _dbConnection.Insert(treatment);
                AddTreatmentToProvider(provider, treatment);


                injury = new()
                {
                    providerInjuryName = "Broken Wrist",
                    providerInjuryDescription = "A broken wrist is a break or crack in one or more of the bones of your wrist. The most common fractures involve the radius and ulna bones in your forearm.",
                    providerInjuryBodyPart = 2
                };
                _dbConnection.Insert(injury);
                AddInjuryToProviderAndTreatment(provider, treatment, injury);


                treatment = new()
                {
                    treatmentName = "Neck Strain Treatment",
                    treatmentDescription = "It 4 day treatment plan that will help you recover and heal the neck strain",
                    treatmentType = 1,
                    treatmentAction = 3
                };
                _dbConnection.Insert(treatment);
                AddTreatmentToProvider(provider, treatment);


                injury = new()
                {
                    providerInjuryName = "Neck Strain",
                    providerInjuryDescription = "A neck strain is an injury to the muscles and tendons that support and move the head and neck. A neck strain is often caused by an accident or trauma, such as a car crash or a fall.",
                    providerInjuryBodyPart = 3
                };
                _dbConnection.Insert(injury);
                AddInjuryToProviderAndTreatment(provider, treatment, injury);


                treatment = new()
                {
                    treatmentName = "Back Pain Treatment",
                    treatmentDescription = "It 5 day treatment plan that will help you recover and heal the back pain",
                    treatmentType = 1,
                    treatmentAction = 4
                };
                _dbConnection.Insert(treatment);
                AddTreatmentToProvider(provider, treatment);

                injury = new()
                {
                    providerInjuryName = "Back Pain",
                    providerInjuryDescription = "Back pain is one of the most common medical problems, affecting 8 out of 10 people at some point during their lives. Back pain can range from a dull, constant ache to a sudden, sharp pain.",
                    providerInjuryBodyPart = 4
                };
                _dbConnection.Insert(injury);
                AddInjuryToProviderAndTreatment(provider, treatment, injury);


                /*
                 * injury = new()
                {
                    providerInjuryName = "Knee Pain",
                    providerInjuryDescription = "Knee pain is a common complaint that affects people of all ages. Knee pain may be the result of an injury, such as a ruptured ligament or torn cartilage. Medical conditions — including arthritis, gout and infections — also can cause knee pain.",
                    providerInjuryBodyPart = 5,
                    providerInjuryServiceProvider = 1
                };
                _dbConnection.Insert(injury);
                treatment.treatmentInjury.Add(injury);
                provider.serviceProviderInjuries.Add(injury);













                action = new()
                {
                    treatmentActionProviderInjury = "Sprained Ankle",
                    treatmentActionStepAction = { "Rest your ankle and do not walk much", "Put some ice on the swelling to reduce it", "Compression can help control swelling as well as immobilize and support your injury", "Keep the foot elevated while sitting or lying down" },
                    treatmentActionStepOrder = 1,
                    treatmentActionFrequency = 1,

                };
                _dbConnection.Insert(action);

                treatment.treatmentInjury.Add(injury);
                provider.serviceProviderInjuries.Add(injury);

                action = new()
                {
                    treatmentActionProviderInjury = "Broken Wrist",
                    treatmentActionStepAction = { "Rest your wrist and do not use it much", "Put some ice on the swelling to reduce it", "Compression can help control swelling as well as immobilize and support your injury", "Keep the wrist elevated while sitting or lying down" },
                    treatmentActionStepOrder = 1,
                    treatmentActionFrequency = 1,

                };
                _dbConnection.Insert(action);

                action = new()
                {
                    treatmentActionProviderInjury = "Neck Strain",
                    treatmentActionStepAction = { "Rest your neck and do not use it much", "Put some ice on the swelling to reduce it", "Compression can help control swelling as well as immobilize and support your injury", "Keep the neck elevated while sitting or lying down" },
                    treatmentActionStepOrder = 1,
                    treatmentActionFrequency = 1,

                };
                _dbConnection.Insert(action);

                frequency = new()
                {
                    treatmentFreqDescription = "Daily",

                };
                _dbConnection.Insert(frequency);

                frequency = new()
                {
                    treatmentFreqDescription = "Every 2 days",

                };
                _dbConnection.Insert(frequency);

                frequency = new()
                {
                    treatmentFreqDescription = "Every week",

                };
                _dbConnection.Insert(frequency);
                */





            }













        }

        public void AddInjuryToProviderAndTreatment(Provider provider, Treatment treatment, ProviderInjury injury)
        {
            treatment.treatmentInjury.Add(injury);
            _dbConnection.UpdateWithChildren(treatment);
            provider.serviceProviderInjuries.Add(injury);
            _dbConnection.UpdateWithChildren(provider);
        }

        public void AddTreatmentToProvider(Provider provider, Treatment treatment)
        {
            provider.serviceProviderTreatments.Add(treatment);
            _dbConnection.UpdateWithChildren(provider);
        }

        public Sport GetSportById(int id)
        {
            Sport sport = _dbConnection.Table<Sport>().Where(x => x.sportID == id).FirstOrDefault();
            if (sport != null)
            {
                _dbConnection.GetChildren(sport,true);
            }
           return sport;
        }
        public User GetUserById(int id)
        {
            User user = _dbConnection.Table<User>().Where(x => x.userID == id).FirstOrDefault();
            if (user != null)
            {
                _dbConnection.GetChildren(user, true);
            }
            return user;
        }

        public Treatment GetTreatmentById(int id)
        {
            Treatment treatment = _dbConnection.Table<Treatment>().Where(x => x.treatmentID == id).FirstOrDefault();
            if (treatment != null)
                _dbConnection.GetChildren(treatment, true);
            return treatment;
        }

        public void InsertClient(User user)
        {
            _dbConnection.Insert(user);
        }   
        public void UpdateClient(User user)
        {

            _dbConnection.Update(user);
        }


    }
}
