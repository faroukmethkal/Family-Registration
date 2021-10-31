using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1WebApi.Data;
using Assignment1WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1WebApi.Controllers
{
    [Route("api/families")]
    [ApiController]
    public class FamiliesController : ControllerBase
    {
        private IServerData serverData;

        public FamiliesController(IServerData serverData)
        {
            this.serverData = serverData;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetAllFamily([FromQuery] int? minAdultAge, int? maxAdultAge,
            bool? hasChild, bool? hasPet)
        {
            IList<Family> families = await serverData.getAllFamily();
            IList<Family> filteredFamily = new List<Family>();

            try
            {
                if (minAdultAge != null && maxAdultAge != null && hasChild != null && hasPet != null)
                {
                    foreach (var family in families)
                    {
                        if (FindFamilyWhereAgeIsBetween(family, minAdultAge, maxAdultAge).Any()
                            && family.Pets.Any() == hasPet && family.Children.Any() == hasChild)
                        {
                            family.Adults = FindFamilyWhereAgeIsBetween(family, minAdultAge, maxAdultAge).ToList();
                            filteredFamily.Add(family);

                        }
                    }

                    return Ok(filteredFamily);
                }
                if (minAdultAge != null && maxAdultAge != null && hasChild != null)
                {
                    foreach (var family in families)
                    {
                        if (FindFamilyWhereAgeIsBetween(family, minAdultAge, maxAdultAge).Any()
                             && family.Children.Any() == hasChild)
                        {
                            family.Adults = FindFamilyWhereAgeIsBetween(family, minAdultAge, maxAdultAge).ToList();
                            filteredFamily.Add(family);

                        }
                    }

                    return Ok(filteredFamily);
                }
                if (minAdultAge != null && maxAdultAge != null && hasPet != null)
                {
                    foreach (var family in families)
                    {
                        if (FindFamilyWhereAgeIsBetween(family, minAdultAge, maxAdultAge).Any()
                            && family.Pets.Any() == hasPet)
                        {
                            family.Adults = FindFamilyWhereAgeIsBetween(family, minAdultAge, maxAdultAge).ToList();
                            filteredFamily.Add(family);

                        }
                    }

                    return Ok(filteredFamily);
                }
              
                
                if (maxAdultAge != null && hasChild != null && hasPet != null)
                {
                    foreach (var family in families)
                    {
                        if (
                            FindFamilyWhereAgeIsLessThan(family, maxAdultAge).Any()
                            && family.Pets.Any() == hasPet && family.Children.Any() == hasChild)
                        {
                            family.Adults = FindFamilyWhereAgeIsLessThan(family, maxAdultAge).ToList();
                            filteredFamily.Add(family);
                        }
                    }
                    
                    return Ok(filteredFamily);
                }
                if (minAdultAge != null && hasChild != null && hasPet != null)
                {
                    foreach (var family in families)
                    {
                        if (
                            FindFamilyWhereAgeIsBiggerThan(family, minAdultAge).Any()
                            && family.Pets.Any() == hasPet && family.Children.Any() == hasChild)
                        {
                            family.Adults = FindFamilyWhereAgeIsBiggerThan(family, minAdultAge).ToList();
                            filteredFamily.Add(family);
                        } 
                        
                    }
                   
                    return Ok(filteredFamily);
                }
                if (minAdultAge != null && maxAdultAge != null)
                {
                    foreach (var family in families)
                    {
                        if (FindFamilyWhereAgeIsBetween(family, minAdultAge, maxAdultAge).Any())
                        {
                            family.Adults = FindFamilyWhereAgeIsBetween(family, minAdultAge, maxAdultAge).ToList();
                            foreach (var adult in family.Adults)
                            {
                                Console.WriteLine(" from api" + adult.Age);
                            }
                            

                            filteredFamily.Add(family);
                        }
                    }
                    Console.WriteLine("----------------------------------");

                    return Ok(filteredFamily);
                }
                if (hasChild != null && hasPet != null)
                {
                    filteredFamily = families.Where(family =>
                        family.Pets.Any() == hasPet && family.Children.Any() == hasChild).ToList();
                    return Ok(filteredFamily);
                }
                if (hasPet != null)
                {
                    filteredFamily = families.Where(family =>
                        family.Pets.Any() == hasPet).ToList();
                    return Ok(filteredFamily);
                }
                if (hasChild != null)
                {
                    filteredFamily = families.Where(family =>
                        family.Children.Any() == hasChild).ToList();
                    return Ok(filteredFamily);
                }
                if (minAdultAge != null)
                {
                    foreach (var family in families)
                    {
                        if (FindFamilyWhereAgeIsBiggerThan(family, minAdultAge).Any())
                        {
                            family.Adults = FindFamilyWhereAgeIsBiggerThan(family, minAdultAge).ToList();
                            filteredFamily.Add(family);
                        }
                    }
                    return Ok(filteredFamily);
                }
                if (maxAdultAge != null)
                {
                    foreach (var family in families)
                    {
                        if (FindFamilyWhereAgeIsLessThan(family, maxAdultAge).Any())
                        {
                            family.Adults = FindFamilyWhereAgeIsLessThan(family, maxAdultAge).ToList();
                            filteredFamily.Add(family);
                        }
                    }
                    
                    return Ok(filteredFamily);
                }

                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500,e.Message);
            }
        }


        private IList<Adult> FindFamilyWhereAgeIsBetween(Family family, int? minAdultAge, int? maxAdultAge)
        {
            return (minAdultAge != null && maxAdultAge != null) ? 
                family.Adults.Where(adult => adult.Age >= minAdultAge && adult.Age <= maxAdultAge).ToList() : null;
        }
        
        private IList<Adult> FindFamilyWhereAgeIsBiggerThan(Family family, int? minAdultAge)
        {
            IList<Adult> adults = minAdultAge != null ? family.Adults.Where(adult => adult.Age >= minAdultAge).ToList() : null;
            return adults;
        }
        
        private IList<Adult> FindFamilyWhereAgeIsLessThan(Family family, int? maxAdultAge)
        {
            IList<Adult> adults = maxAdultAge != null ? family.Adults.Where(adult => adult.Age <= maxAdultAge).ToList() : null;
            return adults;
        }
    }
}