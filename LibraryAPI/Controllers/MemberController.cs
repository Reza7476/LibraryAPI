using LibraryAPI.DTOs.Members;
using LibraryAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace LibraryAPI.Controllers;
[ApiController]
[Route("api/member")]
public class MemberController : ControllerBase
{


    private readonly LibraryDb _db;

    public MemberController(LibraryDb db)
    {
        _db = db;
    }



    [HttpPost("add-member")]
    public void AddMemeber([FromBody] AddMemberDto command)
    {
        var member = new Member(command.Name, command.Email);
        _db.Members.Add(member);
        _db.SaveChanges();
    }

    [HttpGet("get-member")]
    public List<MemberDto>? GetMembers()
    {
        var members = _db.Members.Select(_ => new MemberDto
        {
            Id = _.Id,
            Email = _.Email,
            Name = _.Name,
            RegisterDate = _.RegisterDate.ToString("yyyy.MM.dd")
        }).ToList();
        return members;
    }


    [HttpGet("get-member-by-name/{name}")]
    public MemberDto? GetMember([FromRoute]string name)
    {
        var findMember = _db.Members.FirstOrDefault(_ => _.Name == name);
        if (findMember == null)
        {
            throw new Exception("member not found");
        }
        var member = new MemberDto()
        {
            Email = findMember.Email,
            Name = findMember.Name,
            Id = findMember.Id,
            RegisterDate = findMember.RegisterDate.ToString("yyyy/MM/dddd")
        };
        return member;
    }

    [HttpPut("edit-member/{id}")]
    public void EditMember([FromRoute] int id,[FromBody] EditMemberDto command)
    {
        var member = _db.Members.FirstOrDefault(x => x.Id == id);
        if (member == null)
        {
            throw new Exception("member not Found");
        }

        member.EditMember(command.Name, command.Email);
        _db.SaveChanges();
    }

    [HttpDelete("delete-member/{id}")]
    public void DeleteMember([FromRoute]int id)
    {
        var member = _db.Members.FirstOrDefault(_ => _.Id == id);
        if (member == null)
        {
            throw new Exception("member not found");
        }
        _db.Remove(member);
        _db.SaveChanges();  
    }


}
