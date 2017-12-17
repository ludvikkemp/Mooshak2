$(document).ready(function () {

    var milestone = $(".milestone");
    var addmilestonebutton = $(".addmilestone");
    var milestonenumber = 2;

    addmilestonebutton.on("click", function () {
        $(this).before($("<div class='milestone'>"
            + "    <h3>Milestone " + milestonenumber + "</h3>"
            + "    <div class='form-group'>"
            + "        <label>"
            + "            Milestone " + milestonenumber + " title"
            + "            <input type='text' class='form-control' name='Title'>"
            + "        </label>"
            + "    </div>"
            + "	   <div class='form-group'>"
			+ "	       <label>"
			+ "		       Percentage"
			+ "		       <input type='text' class='form-control' name='Percentage'>"
			+ "        </label>"
			+ "    </div>"
            + "    <div class='form-group'>"
            + "        <label>"
            + "            Submission limit"
            + "            <select name='SubmissionLimit' class='form-control'>"
            + "                <option value='1'>1</option>"
            + "                <option value='2'>2</option>"
            + "                <option value='3'>3</option>"
            + "                <option value='4'>4</option>"
            + "                <option value='5'>5</option>"
            + "                <option value='6'>6</option>"
            + "                <option value='7'>7</option>"
            + "                <option value='8'>8</option>"
            + "                <option value='9'>9</option>"
            + "                <option value='10'>10</option>"
            + "            </select>"
            + "        </label>"
            + "    </div>"
            + "    <div class='form-group input-pairs'>"
            + "        <label>"
            + "            Input 1"
            + "            <input type='text' class='form-control' name='MileStone_Input1'>"
            + "        </label>"
            + "        <label>"
            + "            Output 1"
            + "            <input type='text' class='form-control' name='MileStone_Output1'>"
            + "        </label>"
            + "    </div>"
            + "    <input type='button' value='+ Add input/output' class='btn btn-info addinpoutp'>"
            + "</div>"));
        milestonenumber++;
    });

    var inputpairs = $(".input-pairs");
    var addpairbutton = $(".addpair");
    var pairnumber = 2;

    addpairbutton.on("click", function () {
        $(this).before($("<div class='form-group input-pairs'>"
            + "    <label>"
            + "        Input " + pairnumber
            + "        <input type='text' class='form-control' name='MileStone_Input" + pairnumber + "'>"
            + "    </label>"
            + "    <label>"
            + "        Output " + pairnumber
            + "        <input type='text' class='form-control' name='MileStone_Output" + pairnumber + "'>"
            + "    </label>"
            + "</div>"));
        pairnumber++;
    });
});