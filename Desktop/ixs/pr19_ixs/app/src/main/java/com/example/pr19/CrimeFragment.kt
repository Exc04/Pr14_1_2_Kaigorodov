package com.example.pr19


import android.os.Bundle
import android.text.Editable
import android.text.TextWatcher
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.CheckBox
import android.widget.EditText
import androidx.fragment.app.Fragment
import com.google.android.material.snackbar.Snackbar
import android.text.format.DateFormat
import com.google.android.material.floatingactionbutton.FloatingActionButton
import java.util.Date

class CrimeFragment : Fragment() {

    private lateinit var crime: Crime
    private lateinit var titleField: EditText
    private lateinit var dateButton: Button
    private lateinit var solvedCheckBox: CheckBox
    private lateinit var resetFab: FloatingActionButton

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        crime = Crime()
    }

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val view = inflater.inflate(R.layout.fragment_crime, container, false)
        resetFab = view.findViewById(R.id.reset_fab)
        titleField = view.findViewById(R.id.crime_title)
        dateButton = view.findViewById(R.id.crime_date)
        solvedCheckBox = view.findViewById(R.id.crime_solved)
        resetFab.setOnClickListener{
            titleField.setText("")
            solvedCheckBox.isChecked=false
            crime.date = Date()
            dateButton.text = DateFormat.getDateFormat(requireContext()).format(crime.date)

            Snackbar.make(it,"Форма отправлена",Snackbar.LENGTH_SHORT).show()
        }
        dateButton.apply {

            text = DateFormat.getDateFormat(requireContext()).format(crime.date)
            isEnabled = true
        }

        return view
    }

    override fun onStart() {
        super.onStart()

        val titleWatcher = object : TextWatcher {
            override fun beforeTextChanged(s: CharSequence?, start: Int, count: Int, after: Int) {}
            override fun onTextChanged(s: CharSequence?, start: Int, before: Int, count: Int) {
                crime.title = s.toString()
            }
            override fun afterTextChanged(s: Editable?) {}
        }
        titleField.addTextChangedListener(titleWatcher)

        solvedCheckBox.setOnCheckedChangeListener { view, isChecked ->
            crime.isSolved = isChecked
            Snackbar.make(view, "$isChecked",Snackbar.LENGTH_SHORT).show()
        }
    }
}